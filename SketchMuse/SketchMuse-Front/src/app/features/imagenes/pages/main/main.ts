import { Component } from '@angular/core';
import { Imagen } from '../../models/imagen.model';
import { Imagenes } from '../../../../core/services/imagenes';
import { Buscador } from "../../components/buscador/buscador";
import { ListaImagenes } from "../../components/lista-imagenes/lista-imagenes";

@Component({
  selector: 'app-main',
  imports: [Buscador, ListaImagenes],
  templateUrl: './main.html',
  styleUrl: './main.scss',
})
export class Main {
   imagenes: Imagen[] = []

  constructor(private imagenesService: Imagenes){}

  buscar(query: string){

    this.imagenesService
      .buscarImagenes(query,10)
      .subscribe(data => {
        this.imagenes = data
      })
  }
}
