import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { User } from "../types/user";
import { Observable } from "rxjs";

@Injectable()
export class DataService {
    
    constructor(private http: HttpClient) {}

    get(url: string) {
        return this.http.get(url);
    }

    postUser(url: string, user: User): Observable<User> {
        const httpOptions = {
            headers: new HttpHeaders({
              'Content-Type':  'application/json',
            })
          };

          console.log(user);

        return this.http.post<User>(url, user, httpOptions);
    }

    

}