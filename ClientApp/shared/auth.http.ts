import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Headers, Response } from '@angular/http';
import { HttpClient } from "@angular/common/http";

@Injectable()
export class AuthHttp {

    http:any;
    authKey = "auth";
    e:any;

    constructor(http: HttpClient)
        {// private alertService: AlertService) {
        this.http = http;
    }
    get(url:any, opts = {}) {
        this.configureAuth(opts);
        return this.http.get(url, opts)
            .catch(this.handleHttpError(this.e));
    }
    post(url:any, data:any, opts = {}) {
        this.configureAuth(opts);
        return this.http.post(url, data, opts)
            .catch(this.handleHttpError(this.e));
    }
    put(url:any, data:any, opts = {}) {
        this.configureAuth(opts);
        return this.http.put(url, data, opts)
            .catch(this.handleHttpError(this.e));
    }
    delete(url:any, opts = {}) {
        this.configureAuth(opts);
        return this.http.delete(url, opts)
            .catch(this.handleHttpError(this.e));
    }
    configureAuth(opts: any) {
        var i = localStorage.getItem(this.authKey);
        if (i != null) {
            var auth = JSON.parse(i);
            console.log(auth);
            if (auth.access_token != null) {
                if (opts.headers == null) {
                    opts.headers = new Headers();
                }
                opts.headers.set("If-Modified-Since", `Mon, 26 Jul 1997 05:00:00 GMT`);
                opts.headers.set("Cache-Control", `no-cache`);
                opts.headers.set("Pragma", `no-cache`);
                opts.headers.set("Authorization", `Bearer ${auth.access_token}`);
            }
        }
    }
    //TODO: for all different errors
    handleHttpError(error: any) {

        if (error._body && error._body.length > 0) {
            let em = error._body;
            try {
                em = JSON.parse(error.json().message);
            } catch (e) {
                try {
                    em = error.json().message;
                } catch (e) {
                    console.log(e);
                }
            }
            // this.alertService.error(em, false);
        }
        else {
            // this.alertService.error(error.toString());
        }
        console.log(error);

        return Observable.throw(error);
    }
}