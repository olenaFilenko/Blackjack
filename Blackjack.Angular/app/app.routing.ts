import { Routes, RouterModule } from '@angular/router';
import { ModuleWithProviders } from '@angular/core';

import { HistoryComponent } from './HistoryComponent/history.component';
import { ResultComponent } from './ResultComponent/result.component';
import { PlayComponent } from './PlayComponent/play.component';
import { StartComponent } from './StartComponent/start.component';
import { ErrorComponent } from './ErrorComponent/error.component';

export const appRoutes: Routes = [
    { path: 'history', component: HistoryComponent },
    { path: 'result/:id', component: ResultComponent },
    { path: 'play/:id', component: PlayComponent },
    { path: 'start', component: StartComponent },
    { path: '', redirectTo: 'history', pathMatch: 'full' },
    { path: '**', component: ErrorComponent }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);
