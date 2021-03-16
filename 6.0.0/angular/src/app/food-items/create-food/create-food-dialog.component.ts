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
    FoodServiceProxy,
    CreateFoodInputDto,
    CategoryDto,
    CategoryServiceProxy,
    CategoryDtoListResultDto
  } from '@shared/service-proxies/service-proxies';
  
  @Component({
    templateUrl: 'create-food-dialog.component.html'
  })
  export class CreateFoodDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    food: CreateFoodInputDto = new CreateFoodInputDto();
    categories:CategoryDto[]=[];
  
    @Output() onSave = new EventEmitter<any>();
  
    constructor(
      injector: Injector,
      public _foodService: FoodServiceProxy,
      public bsModalRef: BsModalRef,
      public _categoryService: CategoryServiceProxy
    ) {
      super(injector);
    }
  
    ngOnInit(): void {
      
      this._categoryService.getWithoutPagination().subscribe((result: CategoryDtoListResultDto) => {
        this.categories = result.items;
        
      });
    }
  
    save(): void {
      this.saving = true;
  
      this._foodService
        .createFood(this.food)
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
  