import { Component, OnInit } from '@angular/core';
import { DataService } from '../data/data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(public dataService: DataService) { }

  ngOnInit() {
  }

  start() {
    this.dataService.get('http://localhost:50307/api/Main/Start').subscribe((data) => {});
  }

  stop() {
    this.dataService.get('http://localhost:50307/api/Main/Stop').subscribe((data) => {});
  }

}
