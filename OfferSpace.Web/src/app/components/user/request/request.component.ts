import { Component } from '@angular/core';
import { Request } from 'src/app/models/request.model';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'user-request',
  templateUrl: './request.component.html',
})

export class UserRequestComponent {
  public items: Request[] =[];

  constructor(private service: HttpService) {
    service.get('api/userrequest').subscribe(response => {
      this.items = response as Request[];      
    });
  }
}
