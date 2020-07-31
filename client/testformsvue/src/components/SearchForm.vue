<template>
  <div>
    <form @submit.prevent="SearchForms" class='container'>
      <div class="input-group">
        <input type="text" class="form-control" v-model="searchableText" required />
        <div class="input-group-append">
            <input type="submit" class="btn btn-outline-secondary" value="Search" />
        </div>
      </div>
    </form>
    <div>
      <breakdownMessage v-for="(json, i) in jsonArr" :key="i" :json="json" />
    </div>
  </div>
</template>

<script>
import breakdownMessage from './BreakdownMessage'
export default {
  data () {
    return {
      searchableText: '',
      jsonArr: []
    }
  },
  components: {
    breakdownMessage
  },
  methods: {
    SearchForms () {
      var xhr = new XMLHttpRequest()
      xhr.open('GET', 'http://localhost:56208/breakdownMessages?text=' + this.searchableText, true)
      xhr.send()
      xhr.onreadystatechange = () => {
        if (xhr.status === 200) {
          if (xhr.readyState === 4) {
            this.jsonArr = []
            JSON.parse(xhr.response).forEach(el => {
              this.jsonArr.push(el)
            })
            if (JSON.parse(xhr.response).length === 0) {
              alert('No messages with text ' + this.searchableText)
            }
          }
        } else {
          alert('Error searching!')
        }
      }
    }
  }
}
</script>
<style>
</style>
