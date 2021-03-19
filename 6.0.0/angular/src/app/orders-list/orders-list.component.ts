import { Component, Injector, OnInit } from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';

import {
  PagedListingComponentBase,
  PagedRequestDto,
} from '@shared/paged-listing-component-base';

import {PurchaseOrderServiceProxy,
  PurchaseOrderDtoPagedResultDto,
  PurchaseOrderDto} from '@shared/service-proxies/service-proxies';
  class PagedFoodRequestDto extends PagedRequestDto {
    keyword: string;
   
  }
@Component({
  selector: 'app-orders-list',
  templateUrl: './orders-list.component.html',
  styleUrls: ['./orders-list.component.css'],
  animations: [appModuleAnimation()]
})
export class OrdersListComponent extends PagedListingComponentBase<PurchaseOrderDto>  {

  purchasedItems:   PurchaseOrderDto [] = [];
  keyword = '';
  constructor(injector:Injector,
    private _purchaseOrderServiceProxy:PurchaseOrderServiceProxy) { 
      super(injector);
    }

    list(
      request: PagedFoodRequestDto,
      pageNumber: number,
      finishedCallback: Function
    ): void {
     
      this._purchaseOrderServiceProxy
       .getOrderList(
            request.skipCount,
          request.maxResultCount
        )
        .pipe(
          finalize(() => {
            finishedCallback();
          })
        )
        .subscribe((result: PurchaseOrderDtoPagedResultDto) => {
          this.purchasedItems = result.items;
          this.showPaging(result, pageNumber);
        });
    }

  // ngOnInit(): void {
  // }

  delete():void{

  }
}
