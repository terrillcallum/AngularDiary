import { Component } from '@angular/core';
import { AuthenticationService } from './authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  email = '';
  password = '';

  constructor(private authService: AuthenticationService) { }

  login() {
    this.authService.login(this.email, this.password).subscribe(
      data => {
        // Navigate to a different page or show a success message
      },
      error => {
        // Show an error message
      }
    );
  }
}
