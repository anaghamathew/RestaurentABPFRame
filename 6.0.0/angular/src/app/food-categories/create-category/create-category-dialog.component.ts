import {
    Component,
    Injector,
    OnInit,
    Output,
    EventEmitter
  } from '@angular/core';
  import { finalize } from 'rxjs/operators';
  import { BsModalRef } from 'ngx-bootstrap/modal';
  import { AppComponentBase } from '@shared/app-component-base';
  import {
    CategoryServiceProxy,
  CategoryDto
  } from '@shared/service-proxies/service-proxies';
  
  @Component({
    templateUrl: 'create-category-dialog.component.html'
  })
  export class CreateCategoryDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    category: CategoryDto = new CategoryDto();
  
    @Output() onSave = new EventEmitter<any>();
  
    constructor(
      injector: Injector,
      public _categoryService: CategoryServiceProxy,
      public bsModalRef: BsModalRef
    ) {
      super(injector);
    }
  
    ngOnInit(): void {
     
    }
  
    save(): void {
      this.saving = true;
  
      this._categoryService
        .create(this.category)
        .pipe(
          finalize(() => {
            this.saving = false;
          })
        )
        .subscribe(() => {
          this.notify.info(this.l('SavedSuccessfully'));
          this.bsModalRef.hide();
          this.onSave.emit();
        });
    }
  }
  