import { Component } from '@angular/core';
import { Auth } from '../../../../core/services/auth';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-register',
  imports: [ CommonModule,
    FormsModule,],
  templateUrl: './register.html',
  styleUrl: './register.scss',
})
export class Register {
  email = '';
  password = '';
  errorMessage = '';

  constructor(private authService: Auth, private router: Router) {}

  onSubmit() {
    this.authService.register(this.email, this.password).subscribe({
      next: (res) => {
        this.router.navigate(['/me']);
      },
      error: (err) => {
        // Mostrar mensaje de error
        this.errorMessage = err.error?.message || 'Error en registro';
      }
    });
  }
}
