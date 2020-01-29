import { HttpClient, HttpParams, HttpResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";import { map } from "rxjs/operators";
import { JwtHelperService } from "@auth0/angular-jwt";
import { environment } from "src/environments/environment";
import { Observable } from 'rxjs';

@Injectable({
    providedIn: "root"
})
export class AuthService {
    baseUrl = environment.apiUrl + "auth/";
    jwtHelper = new JwtHelperService();
    decodedToken: any;

    constructor(private http: HttpClient) { }

    login(model: any) {
        return this.http.post(this.baseUrl + "login", model).pipe(
            map((response: any) => {
                const user = response;
                console.log(user);
                if (user) {
                    localStorage.setItem("token", user.token);
                    console.log(localStorage.getItem("role"));
                    this.decodedToken = this.jwtHelper.decodeToken(user.token);
                }
            })
        );
    }

    register(model: any) {
        return this.http.post(this.baseUrl + "register", model);
    }

    loggedIn() {
        const token = localStorage.getItem("token");
        return !this.jwtHelper.isTokenExpired(token);
    }

    isExistEmail(email: string): Observable<HttpResponse<any>> {
        return this.http.get(this.baseUrl + 'emailExist', {
            params: new HttpParams()
                .set('email', email)
            , observe: 'response'
        });
    }
}
