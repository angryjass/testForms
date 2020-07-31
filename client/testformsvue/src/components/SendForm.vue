<template>
  <div>
    <form class='container' name='breakdownMessage' @submit.prevent="SendBreakdownMessage">
      Name
      <input type='text' class="form-control" name='Name' min="2" required />
      Email
      <input type='email' class="form-control" name='Email' required />
      Problem
      <textarea class="form-control" name='Problem' />
      Car Part
      <select name="Car Part" class="custom-select">
        <option selected='selected'>Engine</option>
        <option>Front suspension</option>
        <option>Rear suspension</option>
        <option>Body</option>
        <option>Electric</option>
      </select>
      Tenure
      <ul class="input-group">
      <li class="input-group-prepend"><label class="input-group-text"><input type='radio' class='radio' name='Tenure' value='less than 1' checked />less than 1</label></li>
      <li class="input-group-prepend"><label class="input-group-text"><input type='radio' class='radio' name='Tenure' value='up to 5' />up to 5</label></li>
      <li class="input-group-prepend"><label class="input-group-text"><input type='radio' class='radio' name='Tenure' value='5-9' />5-9</label></li>
      <li class="input-group-prepend"><label class="input-group-text"><input type='radio' class='radio' name='Tenure' value='10 and more' />10 and more</label></li>
      </ul>
      Date
      <input type='date' name="Date" class="form-control" required />
      <div class="text-right">
      <input type='submit' class="btn btn-success m-3" style="width: 100px;" value='Submit' />
      </div>
    </form>
  </div>
</template>

<script>
export default {
  data () {
    return {
      name: '',
      carPart: '',
      email: '',
      problemText: '',
      selectedTenure: '1',
      date: ''
    }
  },
  methods: {
    SendBreakdownMessage () {
      var xhr = new XMLHttpRequest()
      var formData = new FormData(document.forms.breakdownMessage)
      var object = {}
      formData.forEach((value, key) => { object[key] = value })
      var json = JSON.stringify(object)
      xhr.open('POST', 'http://localhost:56208/breakdownMessages', true)
      xhr.setRequestHeader('Content-type', 'application/json; charset=utf-8')
      xhr.send(json)
      console.log(json)
      xhr.onreadystatechange = () => {
        if (xhr.status !== 200) {
          alert('Error sending!')
        } else {
          document.forms.breakdownMessage.reset()
        }
      }
    }
  }
}
</script>
<style>
textarea{
  resize: none;
}
</style>
