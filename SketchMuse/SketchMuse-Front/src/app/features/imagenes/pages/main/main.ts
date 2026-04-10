import { Component, ChangeDetectorRef } from '@angular/core';
import { Imagen } from '../../models/imagen.model';
import { Imagenes } from '../../../../core/services/imagenes';
import { Buscador } from "../../components/buscador/buscador";
import { ListaImagenes } from "../../components/lista-imagenes/lista-imagenes";
import { Auth } from '../../../../core/services/auth';
import { CommonModule } from '@angular/common';
import { Router, RouterLink, RouterModule } from '@angular/router';

@Component({
  selector: 'app-main',
  imports: [Buscador, ListaImagenes, CommonModule, RouterModule],
  templateUrl: './main.html',
  styleUrl: './main.scss',
})
export class Main {
  imagenes: Imagen[] = []

  constructor(private router: Router, private authService: Auth) { }

  get isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }

  buscar(query: string) {
    this.router.navigate(['/references', query]);
  }
}