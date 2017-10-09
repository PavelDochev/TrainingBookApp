import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { AuthService } from "./auth/auth.service";
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { MaterialModule,MdButtonModule, MdCardModule, MdMenuModule, MdToolbarModule, MdIconModule } from '@angular/material';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';
import { FlexLayoutModule } from "@angular/flex-layout";
import { TranslateModule, TranslateLoader } from "@ngx-translate/core";
import { HttpLoaderFactory } from "./app.module.browser";
@NgModule({
    declarations: [
        AppComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        BrowserAnimationsModule,
        MdButtonModule,
        MdMenuModule,
        MdCardModule,
        MdToolbarModule,
        MdIconModule,
        MaterialModule,
        HttpClientModule,
        FlexLayoutModule,
        TranslateModule.forRoot({
            loader: {
                provide: TranslateLoader,
                useFactory: HttpLoaderFactory,
                deps: [HttpClient]
            }
        }),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'callback', component: HomeComponent},
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers:[AuthService],
    exports:[TranslateModule]
    
})
export class AppModuleShared {
}
