import { NgModule } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './AppComponent/app.component';
import { HistoryComponent } from './HistoryComponent/history.component';
import { StartComponent } from './StartComponent/start.component';
import { PlayComponent } from './PlayComponent/play.component';
import { ResultComponent } from './ResultComponent/result.component';
import { ErrorComponent } from './ErrorComponent/error.component';

import { GameService } from './shared/Service/game.service';
import { appRoutes } from './app.routing';

@NgModule({
    imports: [BrowserModule, ReactiveFormsModule, HttpModule, RouterModule.forRoot(appRoutes) ],
    declarations: [AppComponent, HistoryComponent, StartComponent, PlayComponent, ResultComponent, ErrorComponent],
    providers: [GameService, { provide: APP_BASE_HREF, useValue: '/' }],
    bootstrap: [AppComponent]
})

export class AppModule { }