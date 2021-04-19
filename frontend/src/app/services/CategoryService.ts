import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import Category from '../models/Category';
import { ApiEndPoints } from '../config/Config';
import { map } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(
    private http : HttpClient
  ) { }

  public GetCategories() : Observable<Category>
  {
    return this.http.get<Category>(ApiEndPoints.categoryList).pipe(
      map(
        (data:any) => data.map(
          (item:any) => {
              const model = new Category;
              model.Title = item.title;
              model.Slug = item.slug;
              return model;
          }
      )

      )
    )
  }
}
