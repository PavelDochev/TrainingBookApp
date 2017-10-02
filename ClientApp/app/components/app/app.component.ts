import { Component, ViewEncapsulation } from '@angular/core';
import { AuthService } from "../../auth/auth.service";

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    encapsulation: ViewEncapsulation.None
})
export class AppComponent {
    constructor(private auth: AuthService) {
    // Check for authentication and handle if hash present
    this.auth.handleAuthentication();
  }
}
