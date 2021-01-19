import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes =[
    { path: 'battleField', loadChildren: () => import('./battle-field/battle-field.module').then(_ => _.BattleFieldModule)},
    { path: 'registration', loadChildren: () => import('./registration/registration.module').then(_ => _.RegistrationModule)},
    { path: '', loadChildren: () => import('./login/login.module').then(_ => _.LoginModule)}
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }