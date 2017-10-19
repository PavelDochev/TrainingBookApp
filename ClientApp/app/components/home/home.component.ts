import { Component, Inject, OnInit } from '@angular/core';
import { Http } from "@angular/http";
import { AuthHttp } from "../../../shared/auth.http";
import { HttpClient } from "@angular/common/http";
import { HomeService } from "../../services/home/home.service";

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})
export class HomeComponent implements OnInit {
    public sportType:any;
    // http:AuthHttp;
    constructor(private http:Http,
                private homeService:HomeService, @Inject('BASE_URL') baseUrl: string)
    {}

    // this.http.get('api/Home/Test').subscribe(data => {
    //   console.log(data);
    // });
    // .subscribe(
    //   (res: any) => {
    //     this.processStep = res;
    //     this.loading = false;
    //   },
    //   (error: any) => {
    //   });
    
    // http.get(baseUrl + 'api/Home/Test').subscribe(result => {
    //         this.sportType =  result.json();
    //     }, error => console.error(error));

    ngOnInit() {
        this.homeService.GetWorkingTest()
        .subscribe((p) => {
            // this.loading = false;
            this.sportType = p;
            console.log(this.sportType);
        },
        (error:any) => {
            // this.loading = false;
            
        })
    }

}

interface WeatherForecast {
    dateFormatted: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;
}