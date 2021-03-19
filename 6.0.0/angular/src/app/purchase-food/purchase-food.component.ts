import { Component, Injector,OnInit,ChangeDetectionStrategy
} from '@angular/core';
import { finalize } from 'rxjs/operators';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { AppComponentBase } from '@shared/app-component-base';
import {
  CategoryServiceProxy,
  CategoryWithDto
  
} from '@shared/service-proxies/service-proxies';
@Component({
  selector: 'app-purchase-food',
  templateUrl: './purchase-food.component.html',
  styleUrls: ['./purchase-food.component.css']
})
export class PurchaseFoodComponent extends AppComponentBase implements OnInit {

  products:CategoryWithDto[]=[];
  constructor(injector: Injector,
    private _categoryService: CategoryServiceProxy,
    private _modalService: BsModalService) { 
       super(injector);
    }

  ngOnInit(): void {
    this._categoryService.getCategorywithFoods().subscribe((result: CategoryWithDto[]) => {
      this.products = result;
      console.log("products", this.products);
      
    });
  }

  addToCart(foodId): void {
    
 }

}
