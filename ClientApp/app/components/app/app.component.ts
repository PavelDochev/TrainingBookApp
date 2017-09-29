import { Component } from '@angular/core';
import { AuthService } from "../../auth/auth.service";

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    constructor(private auth: AuthService) {
    // Check for authentication and handle if hash present
    this.auth.handleAuth();
  }
}
