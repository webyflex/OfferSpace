import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material';
import { MatDialogRef } from '@angular/material';

@Component({
  selector: 'app-user-profile',
  templateUrl: './profile.component.html',
})

export class UserProfileComponent {
  constructor(public thisDialogRef: MatDialogRef<UserProfileComponent>, @Inject(MAT_DIALOG_DATA) public data: string) { }
 
  onCloseConfirm() {
    this.thisDialogRef.close('Confirm');
  }
  onCloseCancel() {
    this.thisDialogRef.close('Cancel');
  }
}
