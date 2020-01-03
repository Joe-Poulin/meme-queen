import { Component, OnInit } from '@angular/core';
import { DataService } from '../data/data.service';
import { User } from '../types/user';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.less']
})
export class UsersComponent implements OnInit {

  public users: User[] = [];

  constructor(private dataService: DataService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.getUsers();
  }

  getUsers() {
    this.dataService.get('http://localhost:50307/api/Main/GetUsers')
      .subscribe((data) => {
        this.users = JSON.parse(JSON.stringify(data));
      });
  }

  addNewUser() {
    //this.router.navigate(['users/new'], {relativeTo:this.route});
  }

  goToEditUser(id: number) {
    this.router.navigate(['users', 'edit', id]);
  }

}
