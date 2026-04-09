import { CommonModule, DatePipe } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-album',
  imports: [CommonModule, DatePipe],
  templateUrl: './album.html',
  styleUrl: './album.scss',
})
export class Album {
  @Input() album: any;
}
