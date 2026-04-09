import { Component } from '@angular/core';
import { Auth } from '../../../../core/services/auth';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-header',
  imports: [RouterModule],
  templateUrl: './header.html',
  styleUrl: './header.scss',
})
export class Header {
  constructor(private authService: Auth) {}

  get isLoggedIn(): boolean {
    return this.authService.isLoggedIn();
  }
}
