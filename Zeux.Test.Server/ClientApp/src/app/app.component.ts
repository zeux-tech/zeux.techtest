import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';
import { AuthenticationService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'zeux-test-app';

  constructor(private authenticationService: AuthenticationService) { }

  ngOnInit() {
    this.authenticationService.login('admin', 'admin') // HARDCODED CREDS
    .pipe(first())
            .subscribe(
                data => {
                },
                error => {
                  alert('cannot get token');
                });
  }
}
