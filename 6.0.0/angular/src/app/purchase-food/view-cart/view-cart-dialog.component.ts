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
    PurchaseOrderServiceProxy,
    FoodServiceProxy,
    PurchaseOrderDtoListResultDto,
    PurchaseOrderDto,
    
    CategoryServiceProxy
    
  } from '@shared/service-proxies/service-proxies';
  
  @Component({
    templateUrl: 'view-cart-dialog.component.html'
  })
  export class ViewCartDialogComponent extends AppComponentBase
    implements OnInit {
    saving = false;
    customer: string;
    totalPrice:number;
    cartItems:PurchaseOrderDto[]=[];
  
    @Output() onSave = new EventEmitter<any>();
  
    constructor(
      injector: Injector,
      public _foodService: FoodServiceProxy,
      public bsModalRef: BsModalRef,
      public _categoryService: CategoryServiceProxy,
      public _purchaseOrderServiceProxy:PurchaseOrderServiceProxy
    ) {
      super(injector);
    }
  
    GetCart():void{
        this.customer="anagha";
        this._purchaseOrderServiceProxy.viewCart(this.customer).subscribe((result: PurchaseOrderDtoListResultDto) => {
          this.cartItems = result.items;
          console.log("cartitems", this.cartItems);
          
        });
    }

    IncreamentQTY(itemId:number):void{
        this._purchaseOrderServiceProxy.incrementQuantity(itemId).subscribe((result: void) => {
            this.GetCart();
            this.GetTotalPrice();
            
          });
        
    }
    DecreamentQTY(itemId:number):void{
        this._purchaseOrderServiceProxy.decrementQuantity(itemId).subscribe((result: void) => {
            this.GetCart();
            this.GetTotalPrice();
            
          });
    }

    EmptyCart():void{
        this._purchaseOrderServiceProxy.emptyCart(this.customer).subscribe((result: void) => {
            this.GetCart();
            this.GetTotalPrice();
            this.notify.info(this.l('Emptied the cart'));
          });
    }
    ConfirmItems():void{
        this._purchaseOrderServiceProxy.confirmPurchase(this.customer).subscribe((result: void) => {
            this.notify.info(this.l('Confirmed purchase Successfully'));
            this.bsModalRef.hide();
          });
    }

    GetTotalPrice():void{
        this.customer="anagha";
        this._purchaseOrderServiceProxy.getTotalPrice(this.customer).subscribe((result: number) => {
            this.totalPrice = result;
           
            
          });

    }
    ngOnInit(): void {
        this.GetCart();
        this.GetTotalPrice();
        
    }


    }

    
  
    // save(): void {
    //   this.saving = true;
  
    //   this._foodService
    //     .createFood(this.food)
    //     .pipe(
    //       finalize(() => {
    //         this.saving = false;
    //       })
    //     )
    //     .subscribe(() => {
    //       this.notify.info(this.l('SavedSuccessfully'));
    //       this.bsModalRef.hide();
    //       this.onSave.emit();
    //     });
    // }
  
  