import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OpportunitiesComponent } from './components/opportunities/opportunities.component';
import { MyAssetsComponent } from './components/my-assets/my-assets.component';
import { HeaderComponent } from './components/header/header.component';
import { TitleCasePipe } from './pipes/title-case.pipe';
import { AuthInterceptor } from './app.auth.interseptor';
import { AssetsFilterPipe } from './pipes/assets-filter.pipe';

@NgModule({
  declarations: [
    AppComponent,
    OpportunitiesComponent,
    MyAssetsComponent,
    HeaderComponent,
    TitleCasePipe,
    AssetsFilterPipe
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
