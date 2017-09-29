import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { AUTH_CONFIG } from './auth.config';
import * as auth0 from 'auth0-js';

// Avoid name not found warnings

@Injectable()
export class AuthService {
  // Create Auth0 web auth instance
  public _auth0 = new auth0.WebAuth({
    clientID: 'gHAXMUxSR5t0r6MpQAOHlylnoPM2mQrr',
    domain: 'training-book.eu.auth0.com',
    responseType: 'token id_token',
    audience: 'https://training-book.eu.auth0.com/userinfo',
    redirectUri: 'http://localhost:5000/callback',      
    scope: 'openid'
  });
  userProfile: any;
  // Create a stream of logged in status to communicate throughout app
  loggedIn: boolean;
  loggedIn$ = new BehaviorSubject<boolean>(this.loggedIn);

  constructor(private router: Router) {
    // If authenticated, set local profile property
    // and update login status subject.
    // If not authenticated but there are still items
    // in localStorage, log out.
    const lsProfile = localStorage.getItem('profile');
    if (this.tokenValid) {
      this.userProfile = JSON.parse(JSON.stringify(lsProfile));
      this.setLoggedIn(true);
    } else if (!this.tokenValid && lsProfile) {
      this.logout();
    }
  }

  setLoggedIn(value: boolean) {
    // Update login status subject
    this.loggedIn$.next(value);
    this.loggedIn = value;
  }

  public login() {
    // Auth0 authorize request
    this._auth0.authorize({
    audience: 'https://training-book.eu.auth0.com/userinfo',
    scope: 'read:order write:order',
    responseType: 'token id_token',
    redirectUri: 'http://localhost:5000/callback'
  });
}
 public handleAuthentication(): void {
    this._auth0.parseHash((err, authResult) => {
      if (authResult && authResult.accessToken && authResult.idToken) {
        window.location.hash = '';
        this.setSession(authResult);
        this.router.navigate(['/home']);
      } else if (err) {
        this.router.navigate(['/home']);
        console.log(err);
      }
    });
  }

  private setSession(authResult:any): void {
    // Set the time that the access token will expire at
    const expiresAt = JSON.stringify((authResult.expiresIn * 1000) + new Date().getTime());
    localStorage.setItem('access_token', authResult.accessToken);
    localStorage.setItem('id_token', authResult.idToken);
    localStorage.setItem('expires_at', expiresAt);
  }

  public logout(): void {
    // Remove tokens and expiry time from localStorage
    localStorage.removeItem('access_token');
    localStorage.removeItem('id_token');
    localStorage.removeItem('expires_at');
    // Go back to the home route
    this.router.navigate(['/']);
  }

  public isAuthenticated(): boolean {
    // Check whether the current time is past the
    // access token's expiry time
    let expire = localStorage.getItem('expires_at')||"";
    const expiresAt = JSON.parse(expire);
    return new Date().getTime() < expiresAt;
  }
  tokenValid(): boolean {
    // Check if current time is past access token's expiration
    let expires=localStorage.getItem('expires at')||"";
    const expiresAt = JSON.parse(expires);
    return Date.now() < expiresAt;
  }


}

//   handleAuth() {
//     // When Auth0 hash parsed, get profile
//     this._auth0.parseHash((err, authResult) => {
//       if (authResult && authResult.accessToken && authResult.idToken) {
//         window.location.hash = '';
//         this._getProfile(authResult);
//       } else if (err) {
//         console.error(`Error authenticating: ${err.error}`);
//       }
//       this.router.navigate(['/']);
//     });
//   }

//   private _getProfile(authResult:any) {
//     // Use access token to retrieve user's profile and set session
//     this._auth0.client.userInfo(authResult.accessToken, (err, profile) => {
//       if (profile) {
//         this._setSession(authResult, profile);
//       } else if (err) {
//         console.error(`Error authenticating: ${err.error}`);
//       }
//     });
//   }

//   private _setSession(authResult:any, profile:any) {
//     // Save session data and update login status subject
//     const expiresAt = JSON.stringify((authResult.expiresIn * 1000) + Date.now());
//     // Set tokens and expiration in localStorage and props
//     localStorage.setItem('access_token', authResult.accessToken);
//     localStorage.setItem('id_token', authResult.idToken);
//     localStorage.setItem('expires_at', expiresAt);
//     localStorage.setItem('profile', JSON.stringify(profile));
//     this.userProfile = profile;
//     // Update login status in loggedIn$ stream
//     this.setLoggedIn(true);
//   }

//   logout() {
//     // Ensure all auth items removed from localStorage
//     localStorage.removeItem('access_token');
//     localStorage.removeItem('id_token');
//     localStorage.removeItem('profile');
//     localStorage.removeItem('expires_at');
//     localStorage.removeItem('authRedirect');
//     // Reset local properties, update loggedIn$ stream
//     this.userProfile = undefined;
//     this.setLoggedIn(false);
//     // Return to homepage
//     this.router.navigate(['/']);
//   }

    
// }