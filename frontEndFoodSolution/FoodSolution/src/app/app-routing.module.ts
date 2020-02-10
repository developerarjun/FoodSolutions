import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './_guards/auth.guard';
import { CustomerMainComponent } from './customer-main/customer-main.component';


const routes: Routes = [
  {
    path:'login',
    component: LoginComponent
  },
  {
    path:'',
    component:CustomerMainComponent,
    canActivate:[AuthGuard]
  },
  {
    path:'**', redirectTo:''
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
