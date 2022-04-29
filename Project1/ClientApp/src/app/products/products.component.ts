import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product';
import { HttpClient, HttpHeaders, HttpParams, HttpRequest } from "@angular/common/http";
import { Produser } from '../models/produser';
import { Account } from '../models/account';
import { Local } from 'protractor/built/driverProviders';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  visibleProductAdd: boolean = false;
  visibleProductUpdate: boolean = false;
  visibleAdmin: boolean = false;
  id: number = null;
  productUrl = 'http://localhost:38169/api/ProductsVal';
  cartUrl = 'http://localhost:38169/api/CartItems';
  userUrl = 'http://localhost:38169/api/user'
  imagePath = 'assets/images/';
  products: Array<Product> = [];
  productuser: Produser = new Produser();
  user: Account = new Account();

  constructor(private httpClient: HttpClient) { }

  ngOnInit() {
    this.isAdmin();
    this.httpClient.get(this.productUrl).subscribe((response: Array<Product>) => {
      this.products = response;
    })
  }

  addProduct() {
    this.visibleProductAdd = true;
  }

  onSub(product: Product) {
    this.httpClient.post(this.productUrl, product).subscribe((response) => {
      if (response) {
        alert("Added successfully")
        this.refreshProducts();
        this.visibleProductAdd = false;
      }
      else {
        alert("Failed");
      }
    })
  }

  refreshProducts() {
    this.httpClient.get(this.productUrl).subscribe((response: Array<Product>) => {
      this.products = response;
    })
  }

  editProduct(id: number) {
    this.id = id;
    this.visibleProductUpdate = true;
  }

  onUpdate(product: Product) {
    product.id = this.id;

    this.httpClient.put(this.productUrl, product).subscribe((response) => {
      if (response) {
        alert("Updated successfully")
        this.refreshProducts();
        this.visibleProductUpdate = false;
      }
      else {
        alert("Failed");
      }
    })
  }

  deleteProduct(id: number) {


    this.httpClient.delete(this.productUrl+'?productid=' + id).subscribe((response) => {
      alert("Delete");
      console.log(id);
      this.refreshProducts();
    })

  }

  onCancel() {
    this.visibleProductAdd = false;
    this.visibleProductUpdate = false;
  }

  isAdmin() {
    this.user.email = localStorage.getItem('token');
    this.httpClient.post(this.userUrl + "/getRole", this.user).subscribe(res => {
      if (res) {
        this.visibleAdmin = true;
      }
      else {
        this.visibleAdmin = false;
      }
    })
  }

  

  addCart(productId: number) {
    if (localStorage.getItem('token') == null) {
      alert("Please login first!");
    }
    else {
      const userEmail = localStorage.getItem('token');

      this.productuser.prodId = productId;
      this.productuser.userEmail = userEmail;

      console.log(this.productuser);

      this.httpClient.post(this.cartUrl+"/addItems", this.productuser).subscribe((response) => {
        if (response) {
          alert("Added successfully")
        }
      })
    }

  }
}
