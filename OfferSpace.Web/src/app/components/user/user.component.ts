import { Component } from '@angular/core';
import { MatDialog } from '@angular/material';
import { UserProfileComponent } from './profile/profile.component';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
})

export class UserComponent {
  constructor(public dialog: MatDialog) { }

  openDialog() {
    this.dialog.open(UserProfileComponent, {});
  }
}
