import { Component, ChangeDetectorRef } from '@angular/core';
import { Auth } from '../../../../core/services/auth';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, CommonModule, RouterModule],
  templateUrl: './login.html',
  styleUrls: ['./login.scss'],
})
export class Login {

  email: string = '';
  password: string = '';
  error: string = '';

  constructor(private authService: Auth,private cdr: ChangeDetectorRef , private router: Router) {}

  onSubmit() {
    this.authService.login(this.email, this.password)
      .subscribe({
        next: (res) => {
          localStorage.setItem('token', res.token);
          this.router.navigate(['/me']);
        },
        error: (err) => {
          this.error = 'Email o contraseña incorrectos';
          this.cdr.detectChanges();
        }
      });
  }
}