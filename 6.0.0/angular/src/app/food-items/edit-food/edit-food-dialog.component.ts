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
  FoodListDto,CreateFoodInputDto, CategoryServiceProxy,
  CategoryDto,
  CategoryDtoListResultDto
  } from '@shared/service-proxies/service-proxies';
  
  @Component({
    templateUrl: 'edit-food-dialog.component.html'
  })
  export class EditFoodDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
     food: CreateFoodInputDto = new CreateFoodInputDto();
    id: number;
    categories:CategoryDto[]=[];
    @Output() onSave = new EventEmitter<any>();
  
    constructor(
      injector: Injector,
      public _foodService: FoodServiceProxy,
      public bsModalRef: BsModalRef,
      public _categoryService:CategoryServiceProxy
    ) {
      super(injector);
    }
  
    ngOnInit(): void {
        this._categoryService.getWithoutPagination().subscribe((result: CategoryDtoListResultDto) => {
             this.categories = result.items;
            
          });
        this._foodService.getFood(this.id).subscribe((result: FoodListDto) => {
          // this.food = result;
          this.food.id=result.id;
          this.food.name=result.name;
          this.food.description=result.description;
          this.food.categoryId=result.categoryId;
          this.food.price=result.price;
          this.food.quantity=result.quantity;
        });
      }
  
    save(): void {
      this.saving = true;
  
      this._foodService
        .updateFood(this.food)
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
  