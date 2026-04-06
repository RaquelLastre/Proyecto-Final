import { Routes } from '@angular/router';
import { Main } from './features/imagenes/pages/main/main';
import { Perfil } from './features/imagenes/pages/perfil/perfil';
import { Referencias } from './features/imagenes/pages/referencias/referencias';

export const routes: Routes = [
     {
    path: '',
    component: Main
  },
  {
    path: 'me',
    component: Perfil
  },{
    path: 'references',
    component: Referencias
  }
];
