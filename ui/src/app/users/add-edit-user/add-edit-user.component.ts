import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { DataService } from '../../data/data.service';
import { Router, ActivatedRoute } from '@angular/router';
import { User } from '../../types/user';
import { Time } from '@angular/common';
 
@Component({
  selector: 'app-add-edit-user',
  templateUrl: './add-edit-user.component.html',
  styleUrls: ['./add-edit-user.component.less']
})
export class AddEditUserComponent implements OnInit {

  userForm: FormGroup;
  isEdit: boolean;
  urlSub: any;
  Id: number;
  User: User;

  firstName: string;
  lastName: string;
  phoneNumber: string;
  usePhoneNumber: boolean;
  emailAddress: string;
  useEmailAddress: boolean;
  memeTime: Date;

  convertedMemeTime: string;

  constructor(public dataService: DataService,
    public router: Router,
    public route: ActivatedRoute) { }

  ngOnInit() {

    this.firstName = '';
    this.lastName = '';
    this.phoneNumber = '';
    this.usePhoneNumber = false;
    this.emailAddress = '';
    this.useEmailAddress = false;
    this.memeTime = null;

    this.urlSub = this.route.params.subscribe(params => {
      this.Id = params['id'];

      if(this.Id !== undefined) {
        this.isEdit = true;

        this.dataService.get('http://localhost:50307/api/Main/GetUserById?id=' + this.Id)
          .subscribe((data) => {
            this.User = JSON.parse(JSON.stringify(data));

            this.firstName = this.User.FirstName;
            this.lastName = this.User.LastName;
            this.phoneNumber = this.User.PhoneNumber;
            this.usePhoneNumber = this.User.UsePhoneNumber;
            this.emailAddress = this.User.EmailAddress;
            this.useEmailAddress = this.User.UseEmailAddress;
            this.memeTime = this.User.MemeTime;
            
            this.initForm();
          });
      } else {
        this.Id = -1;
      }

      this.initForm();
    });

  }

  initForm() {
    this.userForm = new FormGroup({
      firstName: new FormControl(this.firstName),
      lastName: new FormControl(this.lastName),
      phoneNumber: new FormControl(this.phoneNumber),
      usePhoneNumber: new FormControl(this.usePhoneNumber),
      emailAddress: new FormControl(this.emailAddress),
      useEmailAddress: new FormControl(this.useEmailAddress),
      convertedMemeTime: new FormControl(this.memeTime)
    });
  }

  save() {
    const user = new User(
      this.Id,
      this.userForm.controls['firstName'].value,
      this.userForm.controls['lastName'].value,
      this.userForm.controls['phoneNumber'].value,
      this.userForm.controls['usePhoneNumber'].value,
      this.userForm.controls['emailAddress'].value,
      this.userForm.controls['useEmailAddress'].value,
      this.userForm.controls['memeTime'].value);

    this.dataService.postUser('http://localhost:50307/api/Main/SaveUser', user).subscribe(data => {
      this.router.navigate(['users']);
    });
  }

  goToUsers() {
    if(this.isEdit) {
      this.router.navigate(['../../users']);
    } else {
      this.router.navigate(['../users']);
    }
  }

}
