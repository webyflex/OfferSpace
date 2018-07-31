import { Component } from '@angular/core';
@Component({
  selector: 'my-app',
  template: `
  <iframe #myIframe id="myIframe" (load)="onLoadFunc(myIframe)" src="Account/Token" style="visibility: hidden;"></iframe>
  `
})
export class TokenComponent {
  source: string = '';

  onLoadFunc(myIframe) {
    this.source = myIframe.contentWindow.location.href;
  }
}
