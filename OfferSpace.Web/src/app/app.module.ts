import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { UserComponent } from 'src/app/components/user/user.component';
import { UserRequestComponent } from 'src/app/components/user/request/request.component';
import { HttpService } from 'src/app/services/http.service';

@NgModule({
  declarations: [
    UserComponent,
    UserRequestComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule
  ],
  providers: [
    HttpService,
    { provide: 'BASE_URL', useFactory: getBaseUrl }
  ],
  bootstrap: [UserComponent]
})
export class AppModule { }

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}
