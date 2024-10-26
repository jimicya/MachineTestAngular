import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoansRoutingModule } from './loans-routing.module';
import { LoansComponent } from './loans.component';
import { LoanAddComponent } from './loan-add/loan-add.component';
import { LoanListComponent } from './loan-list/loan-list.component';
import { LoanEditComponent } from './loan-edit/loan-edit.component';
import { CustomersComponent } from './customers.component';
import { CustomerAddComponent } from './customer-add/customer-add.component';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { CustomerEditComponent } from './customer-edit/customer-edit.component';


@NgModule({
  declarations: [LoansComponent, LoanAddComponent, LoanListComponent, LoanEditComponent, CustomersComponent, CustomerAddComponent, CustomerListComponent, CustomerEditComponent],
  imports: [
    CommonModule,
    LoansRoutingModule
  ]
})
export class LoansModule { }
