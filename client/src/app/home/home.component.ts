import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode=false;
  users: any;
  constructor(private http:HttpClient) { }

  ngOnInit(): void {
    
  }

  registerToggle(){
    this.registerMode=!this.registerMode;
    
  }
/*
  getusers(){
    this.http.get('https://localhost:5001/api/users').subscribe(users => this.users=users);
    // this.httpClient.get('https://localhost:5001/api/users').subscribe(users => this.users=users);
  }
*/
  cancelRegisterMode(event: boolean){
    this.registerMode=event;
  }

    
}
