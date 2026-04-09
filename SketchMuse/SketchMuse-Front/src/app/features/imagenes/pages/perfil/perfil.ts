import { Component, OnInit } from '@angular/core';
import { AlbumService } from '../../../../core/services/album/album-service';
import { Album } from "../../components/album/album";
import { CommonModule } from '@angular/common';
import { Auth } from '../../../../core/services/auth';

@Component({
  selector: 'app-perfil',
  standalone: true,
  imports: [Album, CommonModule],
  templateUrl: './perfil.html',
  styleUrl: './perfil.scss',
})
export class Perfil implements OnInit {
  
  albumes: any[] = [];

  constructor(private albumService: AlbumService, private authService: Auth) {}

  ngOnInit(): void {
    console.log('Usuario logueado:', this.authService.isLoggedIn(), localStorage.getItem('token'));
    

    this.albumService.getMisAlbumes().subscribe({
      next: data => this.albumes = data,
      error: err => console.error(err)
    });
    
    console.log('Álbumes recibidos:', this.albumes);
  }
}