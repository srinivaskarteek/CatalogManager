import { Injectable } from '@angular/core';
import { IPackageDetails  } from '../models/packageDetails';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { IPackage } from '../models/package';

@Injectable({
  providedIn: 'root',
})
export class PackageService {

  constructor(private http: HttpClient) { }
  packagesUrl="https://cswappkr.azurewebsites.net/api/package/";
  /** GET heroes from the server */
  getPackageDetails (): Observable<IPackage> {
  let a = this.http.get<IPackage>(this.packagesUrl).pipe(
        catchError(this.handleError('getProducts', null))
      );
      alert(a);
      console.log(a);
      (a);
      return a;
  }

  getPackageDetailsBasedOnId (id: Int32Array): Observable<IPackage> {
    return this.http.get<IPackage>(this.packagesUrl + '/' + id).pipe(
          catchError(this.handleError('getProducts', null))
        );
    }

/**
 * Handle Http operation that failed.
 * Let the app continue.
 * @param operation - name of the operation that failed
 * @param result - optional value to return as the observable result
 */
private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
     // this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
