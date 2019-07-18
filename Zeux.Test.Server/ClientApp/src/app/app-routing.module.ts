import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MyAssetsComponent } from './components/my-assets/my-assets.component';
import { OpportunitiesComponent } from './components/opportunities/opportunities.component';

const routes: Routes = [
  {
    path: 'my-assets/:type',
    component: MyAssetsComponent
  },
  {
    path: 'opportunities',
    component: OpportunitiesComponent
  },
  {
    path: '**',
    redirectTo: 'my-assets/all'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
