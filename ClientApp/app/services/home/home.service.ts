import { Observable } from 'rxjs';
import { Injectable, Inject } from '@angular/core';
import { Http, Response, Headers, RequestOptions, URLSearchParams, RequestOptionsArgs } from '@angular/http';
import { AuthHttp } from "../../../shared/auth.http";

@Injectable()
export class HomeService {

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
    }

    GetWorkingTest() {
        return this.http.get(this.baseUrl + 'api/SampleData/WeatherForecasts').map((result:any) => {
            let test = result.json();
            console.log(test);
        }, (error:any) => console.error(error));
        // return this.http.get('api/SampleData/WeatherForecasts', )
        //     .map((response:Response) => {
        //         let p = response.json();
        //         let t:any[] = [];
        //         p.forEach((element:any) => {
        //             t.push(`./assets/carousel/${element}`);
        //         });
        //         return t;
        //     });
    }
}
