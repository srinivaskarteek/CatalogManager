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
import { HttpClientModule }  from '@angular/common/http';
import { PackagefamilyComponent } from './packagefamily/packagefamily.component';
import { DevicefamilyComponent } from './devicefamily/devicefamily.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    NavComponent,
    PackagelistComponent,
    PackageDetailsComponent,
    PackageAddComponent,
    PackagefamilyComponent,
    DevicefamilyComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule.forRoot(),
    HttpClientModule
  ],
  entryComponents: [PackageAddComponent],
  providers: [],
   bootstrap: [AppComponent]
})
export class AppModule { }
