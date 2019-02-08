import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './header/header.component';
import { NavComponent } from './nav/nav.component';
import { PackagelistComponent } from './packagelist/packagelistcomponent';
import { PackageDetailsComponent } from './packagedetails/packagedetails.component';
import { PackageAddComponent } from './packageadd/packageadd.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    NavComponent,
    PackagelistComponent,
    PackageDetailsComponent,
    PackageAddComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule.forRoot()
  ],
  entryComponents:[PackageAddComponent],
  providers: [],
   bootstrap: [AppComponent]
})
export class AppModule { }
