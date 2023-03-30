$(() => {
    //const peopleId = [];
    let num = 0;
    $("#add-rows").on('click', function () {
        console.log("add row");
        $("#ppl-rows").append(AddRow());
    });
    let AddRow = function () {
        num++;
        //peopleId.push(num);
        return `<div class="row person-row" style="margin-bottom: 10px;">
                <div class="col-md-3">
                    <input class="form-control" type="text" name="people[${num}].firstname" placeholder="First Name" />
                </div>
                <div class="col-md-3">
                    <input class="form-control" type="text" name="people[${num}].lastname" placeholder="Last Name" />
                </div>
                <div class="col-md-3">
                    <input class="form-control" type="text" name="people[${num}].age" placeholder="Age" />
                </div>
                <div class="col-md-3">
                    <button id="${num}" type="button" class="btn btn-outline-danger delete-row">Delete Row</button>
                </div>
            </div>`
    }
    $("#ppl-rows").on('click', ".delete-row", function () {
        console.log("delete row");
        const button = $(this);
        const row = button.closest('.row');
        row.remove();

        let counter = 0;
        $(".person-row").each(function () {
            const row = $(this);
            const inputs = row.find('input');
            inputs.each(function () {
                const input = $(this);
                const name = input.attr('name');
                const indexOfDot = name.indexOf('.');
                const attrName = name.substring(indexOfDot + 1);
                input.attr('name', `people[${counter}].${attrName}`);
            });
            counter++;
            num = counter;
        });
    })

});