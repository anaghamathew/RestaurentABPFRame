import { Component, Injector } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import {CreateFoodDialogComponent} from './create-food/create-food-dialog.component';

import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '@shared/paged-listing-component-base';

import {FoodListDto,
  FoodListDtoPagedResultDto,
  FoodServiceProxy,CategoryServiceProxy} from '@shared/service-proxies/service-proxies';

class PagedFoodRequestDto extends PagedRequestDto {
  keyword: string;
 
}
@Component({
  selector: 'app-food-items',
  templateUrl: './food-items.component.html',
  styleUrls: ['./food-items.component.css'],
  animations: [appModuleAnimation()]
})
export class FoodItemsComponent extends PagedListingComponentBase<FoodListDto> {

  foodItems:   FoodListDto [] = [];
  keyword = '';
  constructor(
    injector: Injector,
    private _foodService: FoodServiceProxy,
    private _modalService: BsModalService,
    private _categoryService:CategoryServiceProxy
  ) {
    super(injector);
  }

      list(
        request: PagedFoodRequestDto,
        pageNumber: number,
        finishedCallback: Function
      ): void {
        request.keyword = this.keyword;
       
    
        this._foodService
          .getFoodItems(
            request.keyword,
            request.skipCount,
            request.maxResultCount
          )
          .pipe(
            finalize(() => {
              finishedCallback();
            })
          )
          .subscribe((result: FoodListDtoPagedResultDto) => {
            this.foodItems = result.items;
            this.showPaging(result, pageNumber);
          });
      }

      createFood() : void {
        this.showCreateOrEditFoodDialog();
     }
   
    //  editCategory(category: CategoryDto): void {
    //     this.showCreateOrEditCategoryDialog(category.id);
    //  }
    showCreateOrEditFoodDialog(id?: number): void {
       let createOrEditFoodDialog: BsModalRef;
       if (!id) {
        createOrEditFoodDialog = this._modalService.show(
          CreateFoodDialogComponent,
           {
             class: 'modal-lg',
           }
         );
       } else {
        //  createOrEditCategoryDialog = this._modalService.show(
        //    EditCategoryDialogComponent,
        //    {
        //      class: 'modal-lg',
        //      initialState: {
        //        id: id,
        //      },
        //    }
        //  );
       }
   
       createOrEditFoodDialog.content.onSave.subscribe(() => {
         this.refresh();
       });
     }
      

      delete(food: FoodListDto): void {
        // abp.message.confirm(
        //   this.l('CategoryDeleteWarningMessage', category.name),
        //   undefined,
        //   (result: boolean) => {
        //     if (result) {
        //       this._foodService
        //         .delete(food.id)
        //         .pipe(
        //           finalize(() => {
        //             abp.notify.success(this.l('SuccessfullyDeleted'));
        //             this.refresh();
        //           })
        //         )
        //         .subscribe(() => {});
        //     }
        //   }
        // );
      }
  // ngOnInit(): void {
  // }
    
}