import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AppRouteGuard } from '@shared/auth/auth-route-guard';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { UsersComponent } from './users/users.component';
import { TenantsComponent } from './tenants/tenants.component';
import { RolesComponent } from 'app/roles/roles.component';
import { ChangePasswordComponent } from './users/change-password/change-password.component';
import { FoodCategoriesComponent } from './food-categories/food-categories.component';
import { FoodItemsComponent } from './food-items/food-items.component';
import {PurchaseFoodComponent} from './purchase-food/purchase-food.component';
@NgModule({
    imports: [
        RouterModule.forChild([
            {
                path: '',
                component: AppComponent,
                children: [
                    { path: 'home', component: HomeComponent,  canActivate: [AppRouteGuard] },
                    { path: 'users', component: UsersComponent, data: { permission: 'Pages.Users' }, canActivate: [AppRouteGuard] },
                    { path: 'roles', component: RolesComponent, data: { permission: 'Pages.Roles' }, canActivate: [AppRouteGuard] },
                    { path: 'tenants', component: TenantsComponent, data: { permission: 'Pages.Tenants' }, canActivate: [AppRouteGuard] },
                    { path: 'about', component: AboutComponent },
                    { path: 'update-password', component: ChangePasswordComponent },
                     { path: 'food-categories', component: FoodCategoriesComponent,data:{permission:'Pages.Owners'}, canActivate: [AppRouteGuard]},
                     {path:'food-items',component:FoodItemsComponent,data:{permission:'Pages.Owners'}, canActivate: [AppRouteGuard]},
                     { path: 'purchase-food', component:PurchaseFoodComponent,data:{permission:'Pages.Customers'}, canActivate: [AppRouteGuard]}
                    // {path:'categories-list',
                    //     children :[
                    //         {path:'**',redirectTo:'list',pathMatch:'full'},
                    //         {path:'list',component:CategoriesListComponent}
                    //     ]  
                    // }   
                ]
            }
        ])
    ],
    exports: [RouterModule]
})
export class AppRoutingModule { }
