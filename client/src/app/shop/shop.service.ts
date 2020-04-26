import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';
import { map, delay } from 'rxjs/operators';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopParams';
import { IProduct } from '../shared/models/product';


@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl="https://localhost:5001/api/";
  brands: IBrand[] = [];
  types: IType[] = [];
  brandIdSelected: number;
  typeIdSelected: number;
  //shopParams = new ShopParams();

  constructor(private http: HttpClient) { }
    
    getProducts(shopParams:ShopParams)
    {
      let params = new HttpParams();

        if (shopParams.brandId!== 0) {
          params = params.append('brandId', shopParams.brandId.toString());
          }

        if (shopParams.typeId!== 0) {
          params = params.append('typeId', shopParams.typeId.toString());
        }

        
     if (shopParams.search) {
          params = params.append('search', shopParams.search);
      }  
      params = params.append('sort', shopParams.sort);
      params = params.append('pageIndex', shopParams.pageNumber.toString());
      params = params.append('pageSize', shopParams.pageSize.toString());

       

      return this.http.get<IPagination>(this.baseUrl+'products',{observe:'response', params})
      .pipe(
        map(response=>{
          return response.body;
        })
      );
    }

    getBrands() {
      return this.http.get<IBrand[]>(this.baseUrl + 'products/brands').pipe(
        map(response => {
          this.brands = response;
          return response;
        })
      );
    }
  
    getTypes() {
      return this.http.get<IType[]>(this.baseUrl + 'products/types').pipe(
        map(response => {
          this.types = response;
          return response;
        })
      );
    }
    getProduct(id: number) {
      return this.http.get<IProduct>(this.baseUrl + 'products/' + id);
    }
  
}
