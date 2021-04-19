import { Component, OnInit } from '@angular/core';
import Category from 'src/app/models/Category';
import { CategoryService } from 'src/app/services/CategoryService';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  public Model : Category;
  constructor(
    private _service: CategoryService
  ) { }

  ngOnInit() {
    this._service.GetCategories().subscribe(
      data =>  {
        this.Model = data;
      }
    )
  }

}
