import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ITeam } from './team';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'cors-client';
  teams:ITeam[] = [];

  constructor(private httpClient:HttpClient){}

  public ngOnInit():void{
    this.httpClient.get("api/teams").subscribe((teams)=>{
      this.teams = teams as ITeam[];
  });
  }

}
