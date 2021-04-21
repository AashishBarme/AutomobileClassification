<template>
       <div>
           <form>
               <div class="form-group row">
                  <label class="col-sm-2 col-form-label">Image : </label>
                  <div class="col-sm-10">
                    <input
                      type="file"
                      accept="image/*"
                      @change="UploadImage($event)"
                      id="file-input"
                    />
                  </div>
                </div>


                <div class="form-group row">
                <label class="col-sm-2 col-form-label">Category : </label>
                <div class="col-sm-10">
                    <select required class="form-control" v-model="object.categoryId">
                    <option value="0">-- Select Category --</option>
                    <option
                        v-for="item in CategoriesList"
                        :key="item.id"
                        :value="item.id"
                    >
                        {{ item.title }}
                    </option>
                    </select>
                </div>
                </div>

                <div class="form-group row">
                    <label for="staticEmail" class="col-sm-2 col-form-label">Title :</label>
                    <div class="col-sm-10">
                      <input type="text" v-model="object.title" class="form-control" />
                    </div>
                </div>

                 <button type="button" ref="SubmitButton"  v-on:click="SubmitForm" class="btn btn-primary">Upload</button>
           </form>
       </div>
</template>

<script>
import Upload from './Upload';
export default Upload;
</script>