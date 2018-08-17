import { RouterModule } from '@angular/router';
import { HistoryComponent } from './HistoryComponent/history.component';
import { ResultComponent } from './ResultComponent/result.component';
import { PlayComponent } from './PlayComponent/play.component';
import { StartComponent } from './StartComponent/start.component';
import { ErrorComponent } from './ErrorComponent/error.component';
export var appRoutes = [
    { path: 'history', component: HistoryComponent },
    { path: 'result/:id', component: ResultComponent },
    { path: 'play/:id', component: PlayComponent },
    { path: 'start', component: StartComponent },
    { path: '', redirectTo: 'history', pathMatch: 'full' },
    { path: '**', component: ErrorComponent }
];
export var routing = RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map