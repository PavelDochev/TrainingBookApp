import { Component, ViewEncapsulation } from '@angular/core';
import { AuthService } from "../../auth/auth.service";
import { TranslateService } from "@ngx-translate/core";

@Component({
    selector: 'app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    encapsulation: ViewEncapsulation.None
})
export class AppComponent {
    constructor(private auth: AuthService,
                private translate: TranslateService) {
    // Check for authentication and handle if hash present
    this.auth.handleAuthentication();
    //set default language
    translate.setDefaultLang('bg');
    translate.use('bg');
  }

  switchLanguage(language: string) {
    this.translate.use(language);
  }
}
