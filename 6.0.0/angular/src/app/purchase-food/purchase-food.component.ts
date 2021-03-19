import { Component, Injector,OnInit,ChangeDetectionStrategy
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import {ViewCartDialogComponent} from './view-cart/view-cart-dialog.component';
import {
  CategoryServiceProxy,
  CategoryWithDto,
  PurchaseOrderServiceProxy,
 AddCartInput

  
} from '@shared/service-proxies/service-proxies';
import { from } from 'rxjs';
@Component({
  selector: 'app-purchase-food',
  templateUrl: './purchase-food.component.html',
  styleUrls: ['./purchase-food.component.css'],
  animations: [appModuleAnimation()]
})
export class PurchaseFoodComponent extends AppComponentBase implements OnInit {

  products:CategoryWithDto[]=[];
  addCartInput:AddCartInput=new AddCartInput();
  constructor(injector: Injector,
    private _categoryService: CategoryServiceProxy,
    private _modalService: BsModalService,
    private _purchaseOrderServiceProxy:PurchaseOrderServiceProxy) { 
       super(injector);
    }

  ngOnInit(): void {
    this._categoryService.getCategorywithFoods().subscribe((result: CategoryWithDto[]) => {
      this.products = result;
      console.log("products", this.products);
      
    });
  }

  addToCart(foodId: number): void {
    console.log("foodId",foodId);
    this.addCartInput.foodId=foodId;
    this.addCartInput.customer="anagha";
     this._purchaseOrderServiceProxy.addToCart(this.addCartInput).subscribe(() => {
      this.notify.info(this.l('Added To Cart Successfully'));
     
    });
  }
    
    ViewCart() : void {
      this.showViewCartDialog();
   
    }

    showViewCartDialog(id?: number): void {
      let viewCartDialog: BsModalRef;
      if (!id) {
        viewCartDialog = this._modalService.show(
        ViewCartDialogComponent,
          {
            class: 'modal-lg',
          }
        );
      } 
  
    }
}
