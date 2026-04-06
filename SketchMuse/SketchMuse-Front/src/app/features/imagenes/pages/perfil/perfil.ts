import { Component } from '@angular/core';
import { Album } from '../../components/album/album';

@Component({
  selector: 'app-perfil',
  imports: [Album],
  templateUrl: './perfil.html',
  styleUrl: './perfil.scss',
})
export class Perfil {}
